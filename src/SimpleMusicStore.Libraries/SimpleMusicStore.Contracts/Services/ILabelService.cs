using SimpleMusicStore.Models.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMusicStore.Contracts.Services
{
    public interface ILabelService
    {
        //Task Add(int discogsId);
        Task<LabelView> Find(int id);
    }
}
