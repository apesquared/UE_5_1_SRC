AM_CFLAGS = $(GLOBAL_CFLAGS) -I$(top_srcdir)/common -I$(top_srcdir)/src -I$(top_srcdir)/include
AM_LDFLAGS = $(libpthread_LIBS)

bin_PROGRAMS = iproxy inetcat itcpconnect

iproxy_SOURCES = iproxy.c
iproxy_CFLAGS = $(AM_CFLAGS)
iproxy_LDFLAGS = $(AM_LDFLAGS)
iproxy_LDADD = $(top_builddir)/src/libusbmuxd.la $(top_builddir)/common/libinternalcommon.la

inetcat_SOURCES = inetcat.c
inetcat_CFLAGS = $(AM_CFLAGS)
inetcat_LDFLAGS = $(AM_LDFLAGS)
inetcat_LDADD = $(top_builddir)/src/libusbmuxd.la $(top_builddir)/common/libinternalcommon.la

itcpconnect_SOURCES = itcpconnect.c
itcpconnect_CFLAGS = $(AM_CFLAGS)
itcpconnect_LDFLAGS = $(AM_LDFLAGS)
itcpconnect_LDADD = $(top_builddir)/src/libusbmuxd.la $(top_builddir)/common/libinternalcommon.la

