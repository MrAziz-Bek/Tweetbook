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

    public bool UpdatePost(Post postToUpdate)
    {
        var exists = GetPostById(postToUpdate.Id) is not null;

        if (!exists)
            return false;

        var index = _posts.FindIndex(p => p.Id == postToUpdate.Id);
        _posts[index] = postToUpdate;

        return true;
    }
}