namespace PersonDiary.Contracts.PersonContract
{
    public class PersonDownloadResponse : Response<PersonDownloadResponse>
    {
        public byte[] Biography { get; set; }
    }
}
