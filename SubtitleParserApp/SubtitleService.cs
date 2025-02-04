using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SubtitleParserApp {
    public class SubtitleService {

        private List<CutInfo> cutInfos = new List<CutInfo>();
        private OffsetInfo _offsetInfo = new OffsetInfo();

        public (List<Subtitle> subTitleList, string aditinalText) ReadSubtitlesFromFile(string filePath) {
            // ファイル読み込みと解析のロジック
            var subtitles = new List<Subtitle>();
            var fileLines = File.ReadAllLines(filePath);

            Subtitle currentSubtitle = null;
            StringBuilder currentText = new StringBuilder();
            bool isCompletedReadSubTitle = false;
            StringBuilder aditonalText = new StringBuilder();

            foreach (var line in fileLines) {

                if (isCompletedReadSubTitle) {
                    aditonalText.AppendLine(line);
                    continue;
                }

                if (string.IsNullOrWhiteSpace(line)) {
                    // 空行は字幕エントリの終わりを意味する

                    if (currentText.Length == 0 && subtitles.Count >= 1) {
                        isCompletedReadSubTitle = true;
                        aditonalText.AppendLine(line);
                    }

                    if (currentSubtitle != null) {
                        // 現在の字幕テキストを設定し、リストに追加
                        currentSubtitle.Text = currentText.ToString().Trim();
                        subtitles.Add(currentSubtitle);
                        currentSubtitle = null;
                        currentText.Clear();
                    }
                } else {
                    ParseSubtitle(ref currentSubtitle, ref currentText, line);
                }
            }

            // ファイルの最後に残っている字幕エントリを追加
            if (currentSubtitle != null) {
                currentSubtitle.Text = currentText.ToString().Trim();
                subtitles.Add(currentSubtitle);
            }

            return (subtitles, aditonalText.ToString());
        }

        public void ParseSubtitle(ref Subtitle currentSubtitle, ref StringBuilder currentText, string line) {
            try {
                if (currentSubtitle == null) {
                    // 新しい字幕の開始。連番を設定
                    currentSubtitle = new Subtitle { SeqNo = int.Parse(line.Trim()) };
                } else if (currentSubtitle.StartTime == default(TimeSpan)) {
                    // 時間コード行。開始時間と終了時間を設定
                    var timeCodes = line.Split(new string[] { " --> " }, StringSplitOptions.None);
                    currentSubtitle.StartTime = TimeSpan.Parse(timeCodes[0].Replace(',', '.'));
                    currentSubtitle.EndTime = TimeSpan.Parse(timeCodes[1].Replace(',', '.'));
                } else {
                    // 字幕テキスト行。複数行にわたる可能性があるため、StringBuilderを使用
                    currentText.AppendLine(line);
                }
            } catch (FormatException fEx) {
                throw new Exception($"字幕フォーマットエラー（行: '{line}'）: {fEx.Message}", fEx);
            } catch (Exception ex) {
                throw new Exception($"字幕解析エラー: {ex.Message}", ex);
            }
        }

        public void EditSubtitles(List<Subtitle> subtitles, TimeSpan startTime, TimeSpan endTime, bool deleteInRange) {

            var subtitlesToRemove = new List<Subtitle>();

            foreach (var subtitle in subtitles) {
                if (subtitle.EndTime <= startTime) {
                    continue;
                }

                if (subtitle.StartTime >= endTime) {
                    var offset = endTime - startTime;
                    subtitle.StartTime -= offset;
                    subtitle.EndTime -= offset;
                } else {
                    // 「カット範囲内の字幕は削除する」チェック時
                    if (deleteInRange) {
                        if (subtitle.StartTime >= startTime && subtitle.StartTime < endTime) {
                            // 字幕開始時間がカット範囲内にある場合、削除する
                            subtitlesToRemove.Add(subtitle);
                        } else if (subtitle.EndTime > startTime && subtitle.EndTime <= endTime) {
                            // 字幕終了時間がカット範囲内にある場合、終了時間をカット開始時間に設定
                            subtitle.EndTime = startTime;
                        }
                    }
                }
            }

            // 削除すべき字幕を一括で削除
            foreach (var subtitle in subtitlesToRemove) {
                subtitles.Remove(subtitle);
            }

        }

        public void AdjustmentTimeSubtitles(List<Subtitle> subtitles, TimeSpan startTime, TimeSpan endTime, TimeSpan offset, bool isDelay) {

            foreach (var subtitle in subtitles) {
                if (subtitle.StartTime >= endTime || subtitle.EndTime <= startTime) {
                    continue;
                }

                if (isDelay) {
                    subtitle.StartTime += offset;
                    subtitle.EndTime += offset;
                } else {
                    subtitle.StartTime -= offset;
                    subtitle.EndTime -= offset;
                }
            }
        }

        public string FormatSubtitlesToSrt(List<Subtitle> subtitles) {
            var sb = new StringBuilder();
            foreach (var subtitle in subtitles) {
                sb.AppendLine(subtitle.SeqNo.ToString());
                sb.AppendLine($"{subtitle.StartTime.ToString(@"hh\:mm\:ss\,fff")} --> {subtitle.EndTime.ToString(@"hh\:mm\:ss\,fff")}");
                sb.AppendLine(subtitle.Text);
                sb.AppendLine(); // 空行を追加
            }
            return sb.ToString();
        }

        // カット情報を追加するメソッド
        public void AddCutInfo(TimeSpan start, TimeSpan end) {
            var cutInfo = new CutInfo { Start = start, End = end };
            cutInfos.Add(cutInfo);
        }

        // カット情報を取得するメソッド
        public List<CutInfo> GetCutInfo() {
            return cutInfos;
        }

        // 時間調整情報を追加するメソッド
        public void AddOffsetInfo(TimeSpan offset, bool isDelay) {
            _offsetInfo = new OffsetInfo() { Offset = offset, IsDelay = isDelay };
        }

        // 時間調整情報を取得するメソッド
        public OffsetInfo GetOffsetInfo() {
            return _offsetInfo;
        }

        // 元の動画でのカット位置を計算するメソッド
        public List<CutInfo> CalculateOriginalCutPositions() {
            var originalCutPositions = new List<CutInfo>();
            TimeSpan totalCutDuration = TimeSpan.Zero;

            foreach (var cutInfo in cutInfos) {
                var originalStart = cutInfo.Start + totalCutDuration;
                var originalEnd = cutInfo.End + totalCutDuration;
                originalCutPositions.Add(new CutInfo { Start = originalStart, End = originalEnd });

                totalCutDuration += cutInfo.End - cutInfo.Start;
            }

            return originalCutPositions;
        }

        public string ReplaceGaiji(string sourceText, List<GaijiReplaceInfo> gaijiReplaceInfos) {

            // 指定された各置換ペアについて、テキスト全体で一括置換を実施
            foreach (var pair in gaijiReplaceInfos) {
                // 文字列.Replaceはすべての出現箇所を置換するため、ループ内で使用可能
                sourceText = sourceText.Replace(pair.ReplaceTargetString, pair.AfterReplacementString);
            }

            return sourceText;
        }
    }
}
