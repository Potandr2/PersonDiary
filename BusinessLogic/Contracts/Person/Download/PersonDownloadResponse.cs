using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDiary.Contracts.PersonContract { 
    public class PersonDownloadResponse:Response
    {
        public byte[] Biography { get; set; }
    }
}
