using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.DTO
{
    public class VideoInPut
    {
        public int InPutVideoId { get; set; }                         //直播id

        public DateTime InPutEndTime { get; set; }                   //直播预约结束时间
        public int InPutVideoState { get; set; }                     //直播状态
        public int InPutVideoCollect { get; set; }
    }
}
