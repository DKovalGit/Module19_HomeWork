using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {

        IFriendRepository friendRepository;
        IUserRepository userRepository;

        public FriendService()
        {
            userRepository = new UserRepository();
            friendRepository = new FriendRepository();
        }

        public int FindByEmail(string friendEmail)
        {
            var findUserEntity = userRepository.FindByEmail(friendEmail);

            if (findUserEntity is null) throw new UserNotFoundException();

            return findUserEntity.id;
        }
        public void Create(string friendEmail, User user)
        {
            var user_id = FindByEmail(friendEmail);
            if (user_id == user.Id) throw new WrongFriendException();
            
        }

    }
}
