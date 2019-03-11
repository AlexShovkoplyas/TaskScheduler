using System;
using System.Collections.Generic;
using System.Text;

namespace TaskScheduler.Domain
{
    public class SavePageOptions
    {
        public string Url { get; set; }
        public SaveOption HowToSave { get; set; }
    }

    public enum SaveOption
    {
        ToPdf,
        ToHtml
    }
}
