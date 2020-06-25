using AutoMapper;
using SimpleMusicStore.Entities;

using SimpleMusicStore.Models;
using SimpleMusicStore.Models.Binding;
using SimpleMusicStore.Models.MusicLibraries;
using SimpleMusicStore.Models.View;
using System.Collections.Generic;
using System.Linq;

namespace SimpleMusicStore.UserActivities
{
    public class MappingConfigurations : Profile
    {
        public MappingConfigurations()
        {
            //CreateMap<LabelInfo, Label>();
            //CreateMap<ArtistInfo, Artist>();
            //CreateMap<RecordTrackInfo, Track>();
            //CreateMap<NewRecord, Record>()
            //    .ForMember(r => r.Artist, opt => opt.Ignore())
            //    .ForMember(r => r.Label, opt => opt.Ignore());
            //CreateMap<RecordView, CartItem>();
            //CreateMap<KeyValuePair<int, int>, Item>()
            //    .ForMember(i => i.RecordId, src => src.MapFrom(kvp => kvp.Key))
            //    .ForMember(i => i.Quantity, src => src.MapFrom(kvp => kvp.Value));
            //CreateMap<AddressDetails, Address>();
            //CreateMap<Address, AddressDetails>();
            //CreateMap<Record, RecordDetails>();
            //CreateMap<Record, RecordView>();
            //CreateMap<Label, LabelDetails>();
            //CreateMap<Artist, ArtistDetails>();
            CreateMap<OrderView, OrderDetails>();
            //CreateMap<Item, ItemDetails>()
            //    .ForMember(id => id.Id, src => src.MapFrom(i => i.Record.Id))
            //    .ForMember(id => id.Title, src => src.MapFrom(i => i.Record.Title))
            //    .ForMember(id => id.Image, src => src.MapFrom(i => i.Record.Image))
            //    .ForMember(id => id.Label, src => src.MapFrom(i => i.Record.Label))
            //    .ForMember(id => id.Artist, src => src.MapFrom(i => i.Record.Artist))
            //    .ForMember(id => id.Price, src => src.MapFrom(i => i.Record.Price))
            //    .ForMember(id => id.Quantity, src => src.MapFrom(i => i.Quantity));
            CreateMap<Order, OrderView>();
            CreateMap<ArtistFollow, ArtistFollowDetails>()
                .ForMember(ad => ad.Name, src => src.MapFrom(af => af.Artist.Name))
                .ForMember(ad => ad.Id, src => src.MapFrom(af => af.Artist.Id))
                .ForMember(ad => ad.Image, src => src.MapFrom(af => af.Artist.Image));
            CreateMap<LabelFollow, LabelFollowDetails>()
                .ForMember(ld => ld.Name, src => src.MapFrom(lf => lf.Label.Name))
                .ForMember(ld => ld.Id, src => src.MapFrom(lf => lf.Label.Id))
                .ForMember(ld => ld.Image, src => src.MapFrom(lf => lf.Label.Image));
            CreateMap<Wish, WishDetails>()
                .ForMember(rd => rd.Id, src => src.MapFrom(w => w.Record.Id))
                .ForMember(rd => rd.Title, src => src.MapFrom(w => w.Record.Title))
                .ForMember(rd => rd.Image, src => src.MapFrom(w => w.Record.Image));
            //CreateMap<RecordView, ItemDetails>();
            //CreateMap<Comment, CommentView>()
            //    .ForMember(dto => dto.ByUser, src => src.MapFrom(c => c.User.Name));
            //CreateMap<NewComment, Comment>();
            //CreateMap<EditComment, Comment>();
            //CreateMap<Track, TrackDetails>();
            //CreateMap<Artist, ArtistView>();
            //CreateMap<Label, LabelView>();
            //CreateMap<NewOrder, Order>();
            //CreateMap<NewAddress, Address>();
            //CreateMap<AddressEdit, Address>();
            CreateMap<User, UserDetails>();
            CreateMap<User, SubscriberDetails>()
                .ForMember(s => s.FollowedArtists, src => src.MapFrom(u => u.FollowedArtists.Select(fa => fa.ArtistId)))
                .ForMember(s => s.FollowedLabels, src => src.MapFrom(u => u.FollowedLabels.Select(fa => fa.LabelId)));
            //CreateMap<Record, SearchResult>()
            //    .ForMember(result => result.Name, src => src.MapFrom(r => r.Title))
            //    .ForMember(result => result.ContentType, src => src.MapFrom(r => "Record"));
            //CreateMap<Artist, SearchResult>()
            //    .ForMember(result => result.ContentType, src => src.MapFrom(a => "Artist"));
            //CreateMap<Label, SearchResult>()
            //  .ForMember(result => result.ContentType, src => src.MapFrom(a => "Label"));
            //CreateMap<User, UserClaims>().ReverseMap();
        }
    }
}
