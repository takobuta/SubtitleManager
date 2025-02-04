using System;

namespace SubtitleParserApp {
    public class Subtitle {

        public int SeqNo { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Text { get; set; }
    }
}
