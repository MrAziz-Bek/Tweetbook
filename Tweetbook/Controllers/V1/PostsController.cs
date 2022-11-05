using Microsoft.AspNetCore.Mvc;
using Tweetbook.Contracts;
using Tweetbook.Contracts.V1;
using Tweetbook.Domain;

namespace Tweetbook.Controllers.V1;

public class PostsController : ControllerBase
{
    private List<Post> _posts = new();

    public PostsController()
    {
        for (var i = 0; i < 5; i++)
        {
            _posts.Add(new Post { Id = Guid.NewGuid().ToString() });
        }
    }

    [HttpGet(ApiRoutes.Posts.GetAll)]
    public IActionResult Posts()
    {
        return Ok(_posts);
    }
}