using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTool
{
    internal interface IBlogHandler
    {
        public void BlogPost();
        public void BlogPostList();
        public void BlogPostSearch();
        public void CreatePost();

    }
}
