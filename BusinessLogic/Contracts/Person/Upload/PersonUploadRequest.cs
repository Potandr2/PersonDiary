﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDiary.Contracts.PersonContract
{
    public class PersonUploadRequest:Request
    {
        public int PersonId { get; set; }
        
    }
}
