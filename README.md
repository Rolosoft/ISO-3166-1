# ISO-3166-1

[![rolosoft_public_packages MyGet Build Status](https://www.myget.org/BuildSource/Badge/rolosoft_public_packages?identifier=db3c8e9e-7ae6-4db5-baa6-4d023c925998)](https://www.myget.org/)

## About
ISO-3166-1 country codes as defined in [Frictionless Data](http://data.okfn.org/data/core/country-list)

## Installation
~~~
install-package Rsft.Net.ISO3166_1
~~~

## Usage Example
```C#
var repo = Rsft.Net.ISO3166_1.ISO3166Factory.Create();

var list = repo.GetAllAsync(CancellationToken.None).Result;
```

## Caching and configuration
Optionally pass your own implementation of IConfiguration<CachePolicyConfiguration> into the main factory method (Create(IConfiguration<CachePolicyConfiguration> configuration = null)).

Caching by default (i.e. no configuration parameter suppled) is set to refresh every 24 hours.

