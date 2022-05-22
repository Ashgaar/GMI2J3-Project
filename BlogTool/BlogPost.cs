﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTool
{
    [Serializable]
    public class BlogPost
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public override string ToString()
        {
            return $"Datum: {Date.ToString("yyyy-MM-dd")} Tid: {Date.ToString("hh:mm")}\nRubrik: {Title}\n{Content}\n";
        }
    }
}
