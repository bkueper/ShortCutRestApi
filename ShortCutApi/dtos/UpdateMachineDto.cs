using ShortCutApi.Models;

namespace ShortCutApi.dtos
{
    public class UpdateMachineDto
    {
        public string SerialNumber{get; set;}

        public string MachineName{get; set;}

        public string url{get; set;}

        public int customerId{get; set;}
    }
}