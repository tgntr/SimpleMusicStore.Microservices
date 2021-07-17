using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMusicStore.Contracts.Newsletter
{
    public interface NewsletterGenerator
    {
        Task Generate();
    }
}
