# Getting Started

The easiest way to use this library is by plain ```GitLabClient```

```c#
var client = new GitLabClient("Example-APP");
```

This will let you access unauthenticated GitLab APIs

# Authenticated Access

If you want to access private repositories, personal information or other authorized information. 
Your client should be provided with login details. 
This can be done through use 
```Basic Authentication```,
```OAuth Authentication```
or
```Bearer Token Authentication```

**Basic Authentication**
```C#
var credentials = new Credentials("Username", "Password", AuthenticationType.Basic);
var client = new GitLabClient("Example-APP", "https://example.com", credentials);
```

**OAuth Authentication**
```C#
var credentials = new Credentials("Personal Access Token", AuthenticationType.Oauth);
var client = new GitLabClient("Example-APP", "https://example.com", credentials);
```

**Bearer Token Authentication**
```C#
var credentials = new Credentials("Bearer Token", AuthenticationType.Bearer);
var client = new GitLabClient("Example-APP", "https://example.com", credentials);
```

**!** We strongly recommend using ```OAuth Authentication```
* User password is safe and does not need to be changed
* Token can any time be revoked by the user

Specified login details are immediately checked when creating a new instance of ```GitLabClient```

# Get some data
Getting data is easy after successful creation of ```GitLabClient```.
If you want to receive data from a specific user:
```C#
var user = client.User.Get(259) // Id;
```
If you want to receivce data from authenticated user:
```C#
var user = client.User.Current;
```

# For more information
For more information we ask you to look for available documentation.
If the information is not in the documentation. 
Feel free to contact us or create a new issue with your relevant question