# RazorFields
A universal solution for editable page templates in ASP.NET.
---

While RazorFields are under active development, the project is **fully functional** in it's present state (and being used in several apps of mine). Keep in mind that occassional issues may popup.

## What can RazorFields do?
- simplify your template copywriting
- store actual fields in persistent storage (EntityFramework, more comming soon...)
- generate API for editing whole system at **runtime**

## Documentation
- to be done, see `RazorFields.Demo` project

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

## Planned features
- [ ] Versioned RazorModel (eg. abstract razor model template you can create versions of)
