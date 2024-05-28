using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_api.Models;

namespace backend_api.Interfaces
{
    public interface ISelectedChoicesRepository
    {
        Task<List<SelectedChoices>?> GetSelectedChoices(int id);
        Task<List<SelectedChoices>?> GetSelectedChoices(string id);
    }
}