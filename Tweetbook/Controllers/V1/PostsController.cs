using Microsoft.AspNetCore.Mvc;
using Tweetbook.Contracts.V1;
using Tweetbook.Contracts.V1.Requests;
using Tweetbook.Contracts.V1.Responses;
using Tweetbook.Domain;
using Tweetbook.Services;

namespace Tweetbook.Controllers.V1;

public class PostsController : ControllerBase
{
    private readonly IPostService _postService;

    public PostsController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet(ApiRoutes.Posts.GetAll)]
    public async Task<IActionResult> Posts()
    {
        return Ok(await _postService.GetPostsAsync());
    }

    [HttpGet(ApiRoutes.Posts.Get)]
    public async Task<IActionResult> Get([FromRoute] Guid postId)
    {
        var post = await _postService.GetPostByIdAsync(postId);

        if (post is null)
            return NotFound();

        return Ok(post);
    }

    [HttpPost(ApiRoutes.Posts.Create)]
    public async Task<IActionResult> Create([FromBody] CreatePostRequest postRequest)
    {
        var post = new Post { Name = postRequest.Name };
  
        await _postService.CreatePostAsync(post);

        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";

        var locationUri = baseUrl + "/" + ApiRoutes.Posts.Get.Replace("{postId}", post.Id.ToString());

        var response = new PostResponse { Id = post.Id };

        return Created(locationUri, response);
    }

    [HttpPut(ApiRoutes.Posts.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid postId, [FromBody] UpdatePostRequest request)
    {
        var post = new Post
        {
            Id = postId,
            Name = request.Name
        };

        var updated = await _postService.UpdatePostAsync(post);

        if (updated)
            return Ok(post);

        return NotFound();
    }

    [HttpDelete(ApiRoutes.Posts.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid postId)
    {
        var deleted = await _postService.DeletePostAsync(postId);

        if (deleted)
            return NoContent();

        return NotFound();
    }
}