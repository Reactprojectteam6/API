using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project.Models.Entities;
using final_project.Services;

namespace final_project.Services
{
    public class CommentService : ICommentService
    {     private DataContext  _context;
       public CommentService(DataContext context)
       {  _context=context;

       }
        public Comment addComment(Comment comment)
        {    int max=1;
            var s=_context.Comments.Select(p=>p.id);
             foreach(var i in s)
             { if(max<int.Parse(i)) max=int.Parse(i);

             }
             comment.id=(max+1).ToString();
             _context.Comments.Add(comment);
             _context.SaveChanges();
             return comment;
        }
    }
}