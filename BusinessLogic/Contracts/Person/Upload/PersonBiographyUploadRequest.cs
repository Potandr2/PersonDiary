using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDiary.Contracts.PersonContract.Upload
{
    public class PersonBiographyUploadRequest:Request
    {
        public int PersonId { get; set; }
        public byte[] File { get; set; }
    }
}
