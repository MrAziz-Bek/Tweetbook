namespace Tweetbook.Contracts.V1;

public static class ApiRoutes
{
    public const string ROOT = "api";
    public const string VERSION = "v1";
    public const string BASE = $"{ROOT}/{VERSION}";

    public static class Posts
    {
        public const string GetAll = BASE + "/posts";
        public const string Get = BASE + "/posts/{postId}";
        public const string Create = BASE + "/posts";
    }
}