using SimpleMusicStore.Models.Binding;
using SimpleMusicStore.Models.MusicLibraries;
using System;
using System.Threading.Tasks;

namespace SimpleMusicStore.Contracts
{
	public interface MusicSource
	{
		Task<NewRecord> ExtractInformation(Uri uri);
	}
}
