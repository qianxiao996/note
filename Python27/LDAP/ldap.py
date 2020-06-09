#!/usr/bin/env python
# encoding: utf-8
# http://ldap3.readthedocs.io/tutorial.html#accessing-an-ldap-server
import ldap3
from fileutils import FileUtils
import os
from ldap3 import Connection

def verify(host):
        try:
            print host
            server = ldap3.Server(host, get_info=ldap3.ALL, connect_timeout=30)
            conn = ldap3.Connection(server, auto_bind=True)
            #print server 
            if len(server.info.naming_contexts) > 0:
                for _ in server.info.naming_contexts:
                    if conn.search(_, '(objectClass=inetOrgPerson)'):
                        naming_contexts = _.encode('utf8')
                        #print naming_contexts
                        print host + ': ' + naming_contexts

        except Exception, e:
            pass
            #print e

if __name__ == '__main__':
    for host in FileUtils.getLines('ldap.lst'):
        verify(host)