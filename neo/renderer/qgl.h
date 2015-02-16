/*
===========================================================================

Doom 3 GPL Source Code
Copyright (C) 1999-2011 id Software LLC, a ZeniMax Media company.

This file is part of the Doom 3 GPL Source Code (?Doom 3 Source Code?).

Doom 3 Source Code is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

Doom 3 Source Code is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with Doom 3 Source Code.  If not, see <http://www.gnu.org/licenses/>.

In addition, the Doom 3 Source Code is also subject to certain additional terms. You should have received a copy of these additional terms immediately following the terms and conditions of the GNU General Public License which accompanied the Doom 3 Source Code.  If not, please request a copy in writing from id Software at the address below.

If you have questions concerning this license or the applicable additional terms, you may contact in writing id Software LLC, c/o ZeniMax Media Inc., Suite 120, Rockville, Maryland 20850 USA.

===========================================================================
*/
/*
** QGL.H
*/

#ifndef __QGL_H__
#define __QGL_H__

#if !defined(ID_TYPEINFO)
#include "../glew/GL/glew.h"

#if defined( _WIN32 )

#include "../glew/GL/wglew.h"
#define wglSwapBuffers ::SwapBuffers

#elif defined( __linux__ )
#include "../glew/GL/glxglew.h"
#endif
#endif

#ifndef APIENTRY
#define APIENTRY
#endif
#ifndef WINAPI
#define WINAPI
#endif



//===========================================================================


#if defined( __linux__ )

//GLX Functions
extern XVisualInfo * (*glXChooseVisual)(Display *dpy, int screen, int *attribList);
extern GLXContext(*glXCreateContext)(Display *dpy, XVisualInfo *vis, GLXContext shareList, Bool direct);
extern void (*glXDestroyContext)(Display *dpy, GLXContext ctx);
extern Bool(*glXMakeCurrent)(Display *dpy, GLXDrawable drawable, GLXContext ctx);
extern void (*glXSwapBuffers)(Display *dpy, GLXDrawable drawable);

// make sure the code is correctly using gl everywhere
// don't enable that when building glimp itself obviously..
#if !defined( GLIMP )
#include "../sys/linux/gl_enforce.h"
#endif

#endif // __linux__

#endif
