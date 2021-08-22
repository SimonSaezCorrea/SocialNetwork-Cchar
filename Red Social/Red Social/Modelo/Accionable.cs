using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social
{
    public interface IAccionable
    {
        bool Login(string name, string password);

        bool Register(string name, string password);

        void Logout();

        void Post(string typePost, string content);

        void Post(string typePost, string content, List<User> listStringUser);

        void Follow(User user);

        void Share(Post Posting, List<User> listUser);

        void Visualize();

        void Comment(Post post, string text);

        void Comment(Comment comment, string text);

        bool Like(Comment comment);

        bool Like(Post post);
    }
}
