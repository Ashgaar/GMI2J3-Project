using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTool
{
    internal interface IBlogHandler
    {
        public void BlogPost(string title, string content,DateTime date);
        public void BlogPostList();
        public void BlogPostSearch();
        public void CreatePost(string title, string content,DateTime date);

    }
}
