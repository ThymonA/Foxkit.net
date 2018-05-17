# Foxkit - GitLab API Client Library for .NET

![Logo](foxkit.png){ width=150px }

Foxkit is a client library that provides an easy way to interact with the [GitLab API](https://docs.gitlab.com/ee/api/)

## Usage examples

Basic authentication
```c#
var credentials = new Credentials("ThymonA", "Secret password")
var client = new GitLabClient("ThymonApp", "https://git.thymonexample.com/", credentials);
var currentUser = client.User.Current;

Console.WriteLine("Hello "  user.Username + " your account has been created on " + user.CreatedAt)
```

Oauth authentication
```c#
var credentials = new Credentials("Personal Access Token")
var client = new GitLabClient("ThymonApp", "https://git.thymonexample.com/", credentials);
var currentUser = client.User.Current;

Console.WriteLine("Hello "  user.Username + " your account has been created on " + user.CreatedAt)
```

Bearer authentication
```c#
var credentials = new Credentials("Bearer Token", AuthenticationType.Bearer)
var client = new GitLabClient("ThymonApp", "https://git.thymonexample.com/", credentials);
var currentUser = client.User.Current;

Console.WriteLine("Hello "  user.Username + " your account has been created on " + user.CreatedAt)
```

## Supported Platforms 

* .NET Core 2.0

## Getting Started

Foxkit is a GitLab API client library for .NET and is not released.
```console
Install-Package ....
```

## Documentation

Documentation is available at [http://foxkitnet.readthedocs.io/en/latest/](http://foxkitnet.readthedocs.io/en/latest/)

## Copyright and License
Copyright 2018 Thymon Arens
Licensed under the [MIT License](https://github.com/ThymonA/Foxkit.net/blob/master/LICENSE)