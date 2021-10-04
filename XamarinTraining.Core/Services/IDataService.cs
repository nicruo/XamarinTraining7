using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinTraining.Core.Domain;

namespace XamarinTraining.Core.Services
{
    public interface IDataService
    {
        Task<Character> GetCharacterAsync(int id);
    }
}