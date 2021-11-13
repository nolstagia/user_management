import VueRouter from 'vue-router';

import home from './components/home.vue';
import users from './components/users.vue';
import userInfo from './components/userInfo.vue';
import add from './components/add.vue';
import edit from './components/edit.vue';
import login from './components/login.vue';
import permissions from './components/permissions.vue';
import roles from './components/roles.vue';
import add_role from './components/add_role.vue';
import add_permission from './components/add_permission.vue';
import set_permission from './components/set_permission.vue';
import set_role from './components/set_role.vue';

const routes = [
    { 
        path: '/home',
        name: 'home', 
        component: home 
    },
    { 
        path: '/users',
        name: 'users', 
        component: users 
    },
    { 
        path: '/userInfo/:id',
        name: 'userInfo', 
        component: userInfo
    },
    { 
        path: '/add',
        name: 'add', 
        component: add
    },
    { 
        path: '/edit/:id',
        name: 'edit', 
        component: edit
    },

    { 
        path: '/permissions',
        name: 'permissions', 
        component: permissions
    },

    { 
        path: '/roles',
        name: 'roles', 
        component: roles
    },

    { 
        path: '/add_role',
        name: 'add_role', 
        component: add_role
    },

    { 
        path: '/add_permission',
        name: 'add_permission', 
        component: add_permission
    },


    { 
        path: '/set_role',
        name: 'set_role', 
        component: set_role
    },

    { 
        path: '/set_permission',
        name: 'set_permission', 
        component: set_permission
    },
    
    {
        path: '/',
        name: 'login', 
        component: login,
        meta: {
            loginScreen: true,
        }
    },

   
]


export default new VueRouter({mode: 'history', routes});