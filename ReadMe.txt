This repo contains the source code for the Runbeck coding exercise.  The Visual Studio solution files and folders can be found inside the RunbeckExercise directory.  The necessary dlls and executable to run the program can be found by themselves inside the "Output Files" directory.  This solution can be built using Visual Studio Community Edition 2019, with the default components within the ".NET desktop development" workload installed.

The projects are divided into the following layers:

UI Layer:
	- RunbeckExerciseConsoleApp

Business Layer:
	- Res.RunbeckExercise.Business

Data Access Layer:
	- Res.RunbeckExercise.DataAccess

Surface Layer:
	- Res.RunbeckExercise.Business.Surface
	- Res.RunbeckExercise.DataAccess.Surface
	- Res.RunbeckExercise.Surface

--------------------------------------------------------------------------------------------------------------------

The Surface Layer is designed to include types that fall under the following conditions:

1. The type is public.

2. The type is referenced by multiple projects.

3. The type has very, very minimal dependencies, if any.  Dependencies on other Surface types do not count against
   this condition.

Condition #3 pertains to the overall purpose of this layer: It helps to keep dependency issues under control.

Even though it didn't specifically come up in this coding exercise, sometimes a given project will have multiple
special or third-party dependencies, and that project will be used in multiple production environments for different
clients.  However one client may only use one portion of those dependencies, while another client may only use a
different portion.  Neither client is using the same list of special/third-party dependencies, but for other logical
and architectural reasons, the logic consuming these dependencies still needs to exist within the same project.

In that case, particularly as a solution grows or in the case of a somewhat restrictive production environment,
things can get complicated in trying to support multiple deployments among different clients.  The Surface layer
simplifies this by taking projects with those kinds of dependencies and effectively loosening their coupling with
other projects.  In that case, some higher-tiered projects which do not need certain pieces of dependency-bound
functionality can get away with not referencing some of the implementing projects, but just with referencing their
related, yet relatively dependency-free projects instead.
