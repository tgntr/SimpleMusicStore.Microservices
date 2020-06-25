using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMusicStore.Contracts.Newsletter
{
    public interface Notificator
    {
        Task Send(string subscriber, string news);
    }
}
