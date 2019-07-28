//Интерфейс архиватора doc/docx файлов биографии персоны
namespace PersonDiary.Interfaces
{
    public interface IArchivator
    {
        byte[] Pack(byte[] file);
        byte[] Unpack(byte[] archive);
    }
}
