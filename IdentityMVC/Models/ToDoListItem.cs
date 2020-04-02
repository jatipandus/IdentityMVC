using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityMVC.Models
{
    public class ToDoListItem
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public bool isCompleted { get; set; }

        public virtual string ApplicationUserID { get; set; }
    }
}