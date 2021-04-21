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

        public UserEntity FindByEmail(string friendEmail)
        {
            var findUserEntity = userRepository.FindByEmail(friendEmail);

            if (findUserEntity is null) throw new UserNotFoundException();

            return findUserEntity;
        }
        public Friend Create(string friendEmail, User user)
        {
            var friendEntity = FindByEmail(friendEmail);
            if (friendEntity.id == user.Id) throw new WrongFriendException();

            var createFriendEntity = new FriendEntity()
            {
                user_id = user.Id,
                friend_id = friendEntity.id
            };

            if (this.friendRepository.Create(createFriendEntity) == 0)
                throw new Exception();

            return new Friend()
            {
                user_id = user.Id,
                friend_id = friendEntity.id,
                Email = friendEmail,
                FirstName = friendEntity.firstname,
                LastName = friendEntity.lastname
            };

        }

    }
}
