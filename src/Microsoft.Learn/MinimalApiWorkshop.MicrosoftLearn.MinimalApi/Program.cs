var app = WebApplication.Create();
app.MapGet("helloworld", () => "Hello world!");
app.Run("http://localhost:5000");