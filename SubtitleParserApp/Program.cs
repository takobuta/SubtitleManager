using System;
using System.IO;
using System.Windows.Forms;

namespace SubtitleParserApp {
    internal static class Program {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main() {

            // 例外ハンドラの設定
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SubtitleParserForm());
        }

        // アプリケーションドメインレベルでの未処理例外
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
            LogException(e.ExceptionObject as Exception);
        }

        // UIスレッド内の未処理例外
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e) {
            LogException(e.Exception);
        }

        // 例外情報をログに出力
        static void LogException(Exception ex) {
            if (ex != null) {
                string logPath = Path.Combine(Application.StartupPath, "Logs");
                if (!Directory.Exists(logPath)) {
                    Directory.CreateDirectory(logPath);
                }

                string logFile = Path.Combine(logPath, $"Log_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.txt");
                File.WriteAllText(logFile, ex.ToString());
            }
        }
    }
}
