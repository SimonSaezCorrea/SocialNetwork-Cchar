using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social
{
    public interface Accionable
    {
        bool Login(string name, string password);

        bool Register(string name, string password);

        void Logout();

        void Post(string typePost, string content);

        void Post(string typePost, string content, List<string> listStringUser);

        void Follow(string name);

        void Share(int idPost, List<string> listUser);

        void Visualize();

        void Comment(Post post, string text);

        void Comment(Comment comment, string text);

        void Like(Comment comment);

        void Like(Post post);
    }
}
