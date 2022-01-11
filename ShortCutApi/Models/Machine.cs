namespace ShortCutApi.Models
{
    public class Machine
    {
        public int MachineId{get; set;}

        public string SerialNumber{get; set;}

        public string MachineName{get; set;}

        public string url{get; set;}

        public Customer customer{get; set;}
    }
}