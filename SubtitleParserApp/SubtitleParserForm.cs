using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;

namespace SubtitleParserApp {
    public partial class SubtitleParserForm : Form {

        private readonly SubtitleService _subtitleService = new SubtitleService();
        private List<Subtitle> _subtitles;
        private string _additinalText;
        private string _originalFilePath;
        private string _gaijiReplaceInfoCsvPath = $"{AppDomain.CurrentDomain.BaseDirectory}\\gaijiReplaceInfo.csv";
        // 編集後の未出力状態を管理するフラグ。出力忘れを防ぐために使用する。
        private bool _hasUnsavedChanges;

        public SubtitleParserForm() {
            InitializeComponent();
            GaijiInfoFilePathLabeltextBox1.Text = _gaijiReplaceInfoCsvPath;
            GaijiInfoFilePathLabeltextBox4.Text = _gaijiReplaceInfoCsvPath;
            UpdateUnsavedChangesBanner();
        }

        private void SelectSubtitleFileButton_Click(object sender, EventArgs e) {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "SRT Files (*.srt)|*.srt";
            openFileDialog.Title = "字幕ファイル(*.srt)選択";

            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                _originalFilePath = openFileDialog.FileName;
                FilePathLabeltextBox.Text = _originalFilePath;
                try {
                    (_subtitles, _additinalText) = _subtitleService.ReadSubtitlesFromFile(_originalFilePath);
                    TextCountLabel.Text = $"{_subtitles.Count}件の字幕テキストを読み込みました！";
                    ResetUnsavedChanges();
                } catch (IOException ioEx) {
                    MessageBox.Show($"ファイル読み込みエラー: {ioEx.Message}");
                    throw;
                } catch (Exception ex) {
                    MessageBox.Show($"エラーが発生しました: {ex.Message}");
                    throw;
                }
            }
        }

        private void CutButton1_Click(object sender, EventArgs e) {

            // ユーザー入力の検証
            if (!TimeSpan.TryParse(CutStartTimeTextBox1.Text, out var startTime) ||
                !TimeSpan.TryParse(CutEndTimeTextBox1.Text, out var endTime) ||
                startTime >= endTime) {
                MessageBox.Show("Invalid time range.");
                return;
            }

            // 字幕を編集
            _subtitleService.EditSubtitles(_subtitles, startTime, endTime, DeleteSubtitleCheckBox1.Checked);

            // カット情報を追加
            _subtitleService.AddCutInfo(startTime, endTime);
            MarkAsUnsaved();

            // 字幕データの修正が完了したことをユーザーに通知
            CutResultTextBox1.AppendText($"{startTime.ToString(@"hh\:mm\:ss\.fff")} ～ {endTime.ToString(@"hh\:mm\:ss\.fff")} のカット完了（カット時間：{(endTime - startTime).ToString(@"hh\:mm\:ss\.fff")}）{Environment.NewLine}");

            CutStartTimeTextBox1.Text = string.Empty;
            CutEndTimeTextBox1.Text = string.Empty;
        }

        private void ReplaceGaijiCheckBox1_CheckedChanged(object sender, EventArgs e) {

            SelectGaijiInfoFileButton1.Enabled = ReplaceGaijiCheckBox1.Checked;
            GaijiInfoFilePathLabeltextBox1.Enabled = ReplaceGaijiCheckBox1.Checked;
        }

        private void OutputButton1_Click(object sender, EventArgs e) {

            // 出力ファイルパスの生成
            var directory = Path.GetDirectoryName(_originalFilePath);
            var fileName = Path.GetFileNameWithoutExtension(_originalFilePath);
            var outputPath = Path.Combine(directory, $"{fileName}_edit.srt");

            // 字幕データをSRT形式でフォーマット
            var srtContent = _subtitleService.FormatSubtitlesToSrt(_subtitles);

            // カット情報を出力
            StringBuilder cutInfoSB = new StringBuilder();
            cutInfoSB.AppendLine();
            cutInfoSB.AppendLine("カット情報====================================");
            foreach (var cut in _subtitleService.GetCutInfo()) {

                cutInfoSB.AppendLine(GetFormattedCutInfoString(cut));
            }
            // 元の動画でのカット位置の計算
            var originalCutPositions = _subtitleService.CalculateOriginalCutPositions();
            cutInfoSB.AppendLine("元動画のカット情報============================");
            // カット情報(元動画換算)を出力
            foreach (var cut in originalCutPositions) {

                cutInfoSB.AppendLine(GetFormattedCutInfoString(cut));
            }
            srtContent += cutInfoSB.ToString();

            // 外字の置換をする場合
            if (ReplaceGaijiCheckBox1.Checked) {

                // 文字置換情報CSVファイルを読み込む
                string gaijiInfoCsvPath = GaijiInfoFilePathLabeltextBox1.Text;
                List<GaijiReplaceInfo> gaijiReplaceInfos = new List<GaijiReplaceInfo>();
                try {
                    using (var reader = new StreamReader(gaijiInfoCsvPath, Encoding.UTF8)) {
                        string line;
                        while ((line = reader.ReadLine()) != null) {
                            // CSVの各行をカンマで分割
                            var parts = line.Split(new char[] { ',' }, 2);
                            if (parts.Length == 2) {
                                string target = parts[0].Trim();
                                string replacement = parts[1].Trim();

                                gaijiReplaceInfos.Add(
                                    new GaijiReplaceInfo {
                                        ReplaceTargetString = target,
                                        AfterReplacementString = replacement
                                    }
                                );
                            } else {
                                // ここでは無視
                                continue;
                            }
                        }
                    }
                } catch (Exception ex) {
                    throw new Exception($"文字置換情報ファイルの読み込み中にエラーが発生しました: {ex.Message}");
                }


                srtContent = _subtitleService.ReplaceGaiji(srtContent, gaijiReplaceInfos);

                if (srtContent.Contains("[外:")) {
                    MessageBox.Show($"文字置換情報に含まれない外字が存在します");
                }
            }

            // ファイルに書き込む
            File.WriteAllText(outputPath, srtContent);

            ResetUnsavedChanges();
            MessageBox.Show($"Subtitles saved to: {outputPath}");
        }

        private void SelectMovieFileButton_Click(object sender, EventArgs e) {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Movie Files (*.ts, *.mp4)|*.ts;*.mp4";
            openFileDialog.Title = "動画ファイル選択";

            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                _originalFilePath = openFileDialog.FileName;
                MovieFilePathLabelTextBox.Text = _originalFilePath;
            }
        }

        private void Cutbutton2_Click(object sender, EventArgs e) {

            // ユーザー入力の検証
            if (!TimeSpan.TryParse(CutStartTimeTextBox2.Text, out var startTime) ||
                !TimeSpan.TryParse(CutEndTimeTextBox2.Text, out var endTime) ||
                startTime >= endTime) {
                MessageBox.Show("Invalid time range.");
                return;
            }

            // カット情報を追加
            _subtitleService.AddCutInfo(startTime, endTime);
            MarkAsUnsaved();

            // 字幕データの修正が完了したことをユーザーに通知
            CutResultTextBox2.AppendText($"{startTime.ToString(@"hh\:mm\:ss\.fff")} ～ {endTime.ToString(@"hh\:mm\:ss\.fff")} のカット完了（カット時間：{(endTime - startTime).ToString(@"hh\:mm\:ss\.fff")}）{Environment.NewLine}");

            CutStartTimeTextBox2.Text = string.Empty;
            CutEndTimeTextBox2.Text = string.Empty;
        }

        private void OutputButton2_Click(object sender, EventArgs e) {

            // 出力ファイルパスの生成
            var directory = Path.GetDirectoryName(_originalFilePath);
            var fileName = Path.GetFileNameWithoutExtension(_originalFilePath);
            var outputPath = Path.Combine(directory, $"{fileName}_cutInfot.txt");

            // カット情報を出力
            StringBuilder cutInfoSB = new StringBuilder();
            cutInfoSB.AppendLine("カット情報====================================");
            foreach (var cut in _subtitleService.GetCutInfo()) {

                cutInfoSB.AppendLine(GetFormattedCutInfoString(cut));
            }
            // 元の動画でのカット位置の計算
            var originalCutPositions = _subtitleService.CalculateOriginalCutPositions();
            cutInfoSB.AppendLine();
            cutInfoSB.AppendLine("元動画換算のカット情報============================");
            // カット情報(元動画換算)を出力
            foreach (var cut in originalCutPositions) {

                cutInfoSB.AppendLine(GetFormattedCutInfoString(cut));
            }

            // ファイルに書き込む
            File.WriteAllText(outputPath, cutInfoSB.ToString());

            ResetUnsavedChanges();
            MessageBox.Show($"Subtitles saved to: {outputPath}");
        }

        private string GetFormattedCutInfoString(CutInfo cutInfo) {

            // 出力文字列フォーマット
            string formatted1 = "{0:D2}時間{1:D2}分{2:D2}秒{3:D3}";
            string formatted2 = "{0:D3}分{1:D2}秒{2:D3}";

            string cutStartTimeFormat1 = string.Format(formatted1, cutInfo.Start.Hours, cutInfo.Start.Minutes, cutInfo.Start.Seconds, cutInfo.Start.Milliseconds);
            string cutStartTimeFormat2 = string.Format(formatted2, (int)Math.Floor(cutInfo.Start.TotalMinutes), cutInfo.Start.Seconds, cutInfo.Start.Milliseconds);

            string cutEndTimeFormat1 = string.Format(formatted1, cutInfo.End.Hours, cutInfo.End.Minutes, cutInfo.End.Seconds, cutInfo.End.Milliseconds);
            string cutEndTimeFormat2 = string.Format(formatted2, (int)Math.Floor(cutInfo.End.TotalMinutes), cutInfo.End.Seconds, cutInfo.End.Milliseconds);

            TimeSpan cutSpan = cutInfo.End - cutInfo.Start;
            string cutSpanFormat1 = string.Format(formatted1, cutSpan.Hours, cutSpan.Minutes, cutSpan.Seconds, cutSpan.Milliseconds);

            return $"{cutStartTimeFormat1}（{cutStartTimeFormat2}） ～ {cutEndTimeFormat1}（{cutEndTimeFormat2}）（{cutSpanFormat1}）";
        }

        private void SelectSubtitleFileButton3_Click(object sender, EventArgs e) {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "SRT Files (*.srt)|*.srt";
            openFileDialog.Title = "字幕ファイル(*.srt)選択";

            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                _originalFilePath = openFileDialog.FileName;
                FilePathLabeltextBox3.Text = _originalFilePath;
                try {
                    (_subtitles, _additinalText) = _subtitleService.ReadSubtitlesFromFile(_originalFilePath);
                    TextCountLabel3.Text = $"{_subtitles.Count}件の字幕テキストを読み込みました！";
                    ResetUnsavedChanges();
                } catch (IOException ioEx) {
                    MessageBox.Show($"ファイル読み込みエラー: {ioEx.Message}");
                    throw;
                } catch (Exception ex) {
                    MessageBox.Show($"エラーが発生しました: {ex.Message}");
                    throw;
                }
            }
        }

        private void EditButton3_Click(object sender, EventArgs e) {

            TimeSpan startTime;
            TimeSpan endTime = new TimeSpan(23, 59, 59); // 終了を指定しない場合は最後まで
            TimeSpan offset;
            bool isDelay = DelayRadioButton.Checked;

            // ユーザー入力の検証
            if (!TimeSpan.TryParse(EditStartTimeTextBox3.Text, out startTime) || !TimeSpan.TryParse(OffsetTextBox3.Text, out offset)) {
                MessageBox.Show("Invalid time range.");
                return;
            }
            if (!string.IsNullOrWhiteSpace(EditEndTimeTextBox3.Text) && !TimeSpan.TryParse(EditEndTimeTextBox3.Text, out endTime)) {
                MessageBox.Show("Invalid time range.");
                return;
            }
            if (startTime >= endTime) {
                MessageBox.Show("Invalid time range.");
                return;
            }

            // 字幕を編集
            _subtitleService.AdjustmentTimeSubtitles(_subtitles, startTime, endTime, offset, isDelay);

            // 調整時間情報を追加
            _subtitleService.AddOffsetInfo(offset, isDelay);
            MarkAsUnsaved();

            // 字幕データの修正が完了したことをユーザーに通知
            EditResultTextBox3.AppendText($"{startTime.ToString(@"hh\:mm\:ss\.fff")} ～ {endTime.ToString(@"hh\:mm\:ss\.fff")} の調整完了（{offset.ToString(@"hh\:mm\:ss\.fff")} {(isDelay ? "遅らせる":"早める")}）{Environment.NewLine}");

            EditStartTimeTextBox3.Text = string.Empty;
            EditEndTimeTextBox3.Text = string.Empty;
        }

        private void OutputButton3_Click(object sender, EventArgs e) {

            // 出力ファイルパスの生成
            var directory = Path.GetDirectoryName(_originalFilePath);
            var fileName = Path.GetFileNameWithoutExtension(_originalFilePath);
            var outputPath = Path.Combine(directory, $"{fileName}_edit.srt");

            // 字幕データをSRT形式でフォーマット
            var srtContent = _subtitleService.FormatSubtitlesToSrt(_subtitles);

            // 情報を出力
            var offsetInfo = _subtitleService.GetOffsetInfo();
            var timeEditInfoSb = new StringBuilder();
            timeEditInfoSb.AppendLine();
            timeEditInfoSb.AppendLine("時間調整情報====================================");
            timeEditInfoSb.AppendLine($"{offsetInfo.Offset.ToString(@"hh\:mm\:ss\.fff")} {(offsetInfo.IsDelay ? "遅らせる" : "早める")}");

            srtContent += _additinalText;

            srtContent += timeEditInfoSb.ToString();

            // ファイルに書き込む
            File.WriteAllText(outputPath, srtContent);

            ResetUnsavedChanges();
            MessageBox.Show($"Subtitles saved to: {outputPath}");
        }

        private void SelectSubtitleFileButton4_Click(object sender, EventArgs e) {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "SRT Files (*.srt)|*.srt";
            openFileDialog.Title = "字幕ファイル(*.srt)選択";

            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                _originalFilePath = openFileDialog.FileName;
                FilePathLabeltextBox4.Text = _originalFilePath;
                try {
                    (_subtitles, _additinalText) = _subtitleService.ReadSubtitlesFromFile(_originalFilePath);
                    ResetUnsavedChanges();
                } catch (IOException ioEx) {
                    MessageBox.Show($"ファイル読み込みエラー: {ioEx.Message}");
                    throw;
                } catch (Exception ex) {
                    MessageBox.Show($"エラーが発生しました: {ex.Message}");
                    throw;
                }
            }
        }

        private void OutputButton4_Click(object sender, EventArgs e) {

            string targetText = File.ReadAllText(_originalFilePath, Encoding.UTF8);

            var directory = Path.GetDirectoryName(_originalFilePath);
            var fileName = Path.GetFileNameWithoutExtension(_originalFilePath);
            string outputPath = Path.Combine(directory, $"{fileName}_replace.srt");

            // 文字置換情報CSVファイルを読み込む
            string gaijiInfoCsvPath = GaijiInfoFilePathLabeltextBox4.Text;
            List<GaijiReplaceInfo> gaijiReplaceInfos = new List<GaijiReplaceInfo>();
            try {
                using (var reader = new StreamReader(gaijiInfoCsvPath, Encoding.UTF8)) {
                    string line;
                    while ((line = reader.ReadLine()) != null) {
                        // CSVの各行をカンマで分割
                        var parts = line.Split(new char[] { ',' }, 2);
                        if (parts.Length == 2) {
                            string target = parts[0].Trim();
                            string replacement = parts[1].Trim();

                            gaijiReplaceInfos.Add(
                                new GaijiReplaceInfo {
                                    ReplaceTargetString = target, 
                                    AfterReplacementString = replacement
                                }
                            );
                        } else {
                            // ここでは無視
                            continue;
                        }
                    }
                }
            } catch (Exception ex) {
                throw new Exception($"文字置換情報ファイルの読み込み中にエラーが発生しました: {ex.Message}");
            }

            string replaceText = _subtitleService.ReplaceGaiji(targetText, gaijiReplaceInfos);

            // ファイルに書き込む
            File.WriteAllText(outputPath, replaceText);

            MessageBox.Show($"Subtitles saved to: {outputPath}");
        }

        // 編集後に未出力状態であることを記録する。
        private void MarkAsUnsaved() {
            _hasUnsavedChanges = true;
            UpdateUnsavedChangesBanner();
        }

        // 出力完了後など、未出力状態を解消したタイミングで呼び出す。
        private void ResetUnsavedChanges() {
            _hasUnsavedChanges = false;
            UpdateUnsavedChangesBanner();
        }

        // 未出力状態をユーザーに明示するための視覚的フィードバックとしてバナーの表示を更新する。
        private void UpdateUnsavedChangesBanner() {
            UnsavedChangesPanel.Visible = _hasUnsavedChanges;
        }

        // フォームを閉じる際に、未出力の編集が残っていないかを確認する。
        private void SubtitleParserForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (!_hasUnsavedChanges) {
                return;
            }

            DialogResult result = MessageBox.Show(
                "編集内容がまだ出力されていません。出力せずに終了すると変更は保存されません。終了してもよろしいですか？",
                "未出力の編集内容があります",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.No) {
                e.Cancel = true;
            }
        }        
    }
}
