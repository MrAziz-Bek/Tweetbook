using Tweetbook.Domain;

namespace Tweetbook.Services;

public interface IPostService
{
    Task<Post> GetPostByIdAsync(Guid postId);
    Task<List<Post>> GetPostsAsync();
    Task<bool> CreatePostAsync(Post post);
    Task<bool> UpdatePostAsync(Post postToUpdate);
    Task<bool> DeletePostAsync(Guid postId);
}