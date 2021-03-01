using System;
using System.Collections.Generic;
using creviews.Models;
using creviews.Repositories;

namespace creviews.Services
{
  public class RestaurantProfilesService
  {
    private readonly ProfilesRepository _repo;
    public ProfilesService(ProfilesRepository repo)
    {
      _repo = repo;
    }
    internal Profile GetOrCreateProfile(Profile userInfo)
    {
      Profile profile = _repo.GetById(userInfo.Id);
      if (profile == null)
      {
        return _repo.Create(userInfo);
      }
      return profile;
    }

    internal Profile GetProfileById(string id)
    {
      Profile profile = _repo.GetById(id);
      if (profile == null)
      {
        throw new Exception("Invalid Id");
      }
      return profile;
    }

    // internal IEnumerable<Profile> GetMembersByPartyId(int id)
    // {
    //   return _repo.GetByPartyId(id);
    // }
  }
}