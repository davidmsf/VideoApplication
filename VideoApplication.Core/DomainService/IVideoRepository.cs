using System;
using System.Collections.Generic;
using System.Text;
using VideoApplication.Core.Entity;

namespace VideoApplication.Core.DomainService
{
    interface IVideoRepository
    {
        
        //Read all videoes
        List<Video> ReadAll();

        //Create new video
        Video Create(Video video);



    }
}
