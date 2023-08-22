using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBooks.Application.DTOs
{
    public class PagedBaseResponseDTO<T>
    {
        public int TotalRegisters { get; set; }
        public List<T> Data { get; set; }
        public PagedBaseResponseDTO(int totalRegisters, List<T> data)
        {
            TotalRegisters = totalRegisters;
            Data = data;
        }
    }
}
