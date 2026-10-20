const http = require("http");
const fs = require("fs");
const path = require("path");

const root = __dirname;
const port = 5500;
const mimeTypes = {
  ".css": "text/css; charset=utf-8",
  ".html": "text/html; charset=utf-8",
  ".js": "text/javascript; charset=utf-8",
};

const server = http.createServer((request, response) => {
  if (request.method !== "GET" && request.method !== "HEAD") {
    response.writeHead(405, { Allow: "GET, HEAD" });
    response.end("Method Not Allowed");
    return;
  }

  let pathname;
  try {
    pathname = decodeURIComponent(new URL(request.url, "http://127.0.0.1").pathname);
  } catch (error) {
    response.writeHead(400);
    response.end("Bad Request");
    return;
  }

  const relativePath = pathname.replace(/^\/+|\/+$/g, "") || "index.html";
  const filePath = path.resolve(root, relativePath);
  const pathFromRoot = path.relative(root, filePath);
  if (pathFromRoot === ".." || pathFromRoot.startsWith(`..${path.sep}`) || path.isAbsolute(pathFromRoot)) {
    response.writeHead(403);
    response.end("Forbidden");
    return;
  }

  fs.stat(filePath, (statError, stats) => {
    if (statError || !stats.isFile()) {
      response.writeHead(404);
      response.end("Not Found");
      return;
    }

    response.writeHead(200, {
      "Content-Type": mimeTypes[path.extname(filePath).toLowerCase()] || "application/octet-stream",
    });
    if (request.method === "HEAD") {
      response.end();
      return;
    }

    const stream = fs.createReadStream(filePath);
    stream.on("error", (error) => {
      console.error(`Unable to read ${filePath}:`, error);
      if (!response.headersSent) {
        response.writeHead(500);
      }
      response.end("Internal Server Error");
    });
    stream.pipe(response);
  });
});

console.log("Starting local website server...");
server.listen(port, "127.0.0.1", () => {
  console.log(`Local website ready: http://127.0.0.1:${port}`);
});

server.on("error", (error) => {
  console.error(`Unable to start local website server: ${error.message}`);
  process.exitCode = 1;
});
