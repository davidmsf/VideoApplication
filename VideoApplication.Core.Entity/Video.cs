using System;
using System.Collections.Generic;
using System.Text;

namespace VideoApplication.Core.Entity
{
    public class Video
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public Genre genre { get; set; }
    }
}
