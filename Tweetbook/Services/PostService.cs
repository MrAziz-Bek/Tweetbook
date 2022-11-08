using Tweetbook.Domain;

namespace Tweetbook.Services;

public class PostService : IPostService
{
    private readonly List<Post> _posts = new();

    public PostService()
    {
        for (var i = 0; i < 5; i++)
        {
            _posts.Add(new Post
            {
                Id = Guid.NewGuid(),
                Name = $"Post Name {i}"
            });
        }
    }
    public Post GetPostById(Guid postId)
    {
        return _posts.SingleOrDefault(p => p.Id == postId);
    }

    public List<Post> GetPosts()
    {
        return _posts;
    }
}