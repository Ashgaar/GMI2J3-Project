using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTool
{
    public interface IBlogHandler
    {
        public void BlogPost(string title, string content,DateTime date, string path);
        public void BlogPostList();
        public void BlogPostSearch(string search);
        public void CreatePost(string title, string content,DateTime date);

    }
}
