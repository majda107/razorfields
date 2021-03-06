# RazorFields [![Generic badge](https://img.shields.io/badge/Active%3F-yes-green.svg)](https://shields.io/)
> A universal solution for editable copywriting in ASP.NET core

While RazorFields are under active development, the project is **fully functional** in it's present state (and being used in several apps of mine). Keep in mind that occassional issues may popup.

## What can RazorFields do?
- simplify your template copywriting
- separate copywriting X templating layers
- store actual fields in persistent storage (EntityFramework, more comming soon...)
- generate API for editing whole system at **runtime**

## Documentation
- to be done, see `examples` folder (`RazorFields.Demo` project)

## Nugets
- [Core nuget](https://www.nuget.org/packages/RazorFields)
- [API extension](https://www.nuget.org/packages/RazorFields.Api)
- [EntityFramework extension](https://www.nuget.org/packages/RazorFields.EntityFramework)

## Setup
- register in services `services.AddRazorFields();`

- create public **record** of yours and tag it with a `[RazorModel]` attribute

- inject RazorFields service with DI `private readonly IRazorFieldsService _rfs;`
- query tagged razor models `var razorModel = _rfs.GetModel<HomeRazorModel>();`

### Optional
- add entity framework persistence `services.AddRazorFieldsEntityFramework<DatabaseContext>();`
- create Rest API controller
```
public class RazorFieldsController : RazorFieldsControllerBase
{
    public RazorFieldsController(IRazorFieldsService rfs) : base(rfs)
    {
    }
}
```

## Roadmap
- [x] In-memory razor model caching
- [x] Attribute for injection
- [x] Extension loader 
- [x] EntityFramework connector extension nuget
- [x] Rest API extension nuget  
- [ ] Versioned RazorModel (eg. abstract razor model template you can create versions of)
- [ ] MongoDB connector extension
- [ ] Redis connector extension
- [ ] Admin UI extension
- [ ] Custom distributed cache extension (memory cache, redis)

- [ ] ? Saga-based history extension

## License
RazorFields project is licensed under the [MIT License](https://github.com/majda107/razorfields/blob/master/LICENSE)
