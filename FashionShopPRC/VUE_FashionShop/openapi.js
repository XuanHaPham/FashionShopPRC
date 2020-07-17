export const base = 'https://localhost:44395'

export const methods = {
    GET: 'GET',
    POST: 'POST',
    PUT: 'PUT',
    DELETE: 'DELETE'
}

export const routes = {
    ACCOUNT: '/api/Account',
    USERS: 'Account/AccountsInRole?role=User',
    ADMINS: 'Account/AccountsInRole?role=Admin',
    COUNTUSERS: 'Account/CountUsers',
    USERINFO: 'Account/UserInfo',
    UPDATEPROFILE: 'Account/UpdateProfile',
    CHANGEPASSWORD: 'Account/ChangePassword',
    EVENTS: 'Events',
    EVENTTYPES: 'EventTypes',
    NEWS: 'News',
    ORGANIZATIONS: 'Organizations',
    ORGANIZATIONMEMBER: 'OrganizationMember',
    ROLES: 'Roles',
    CONFIGURATION: 'Configurations',
    SYSTEMRESOURCES: 'SystemResources'
}

export function getToken() {
    return localStorage.getItem('token');
}

export function setToken(data) {
    localStorage.setItem('token', data.access_token);
    localStorage.setItem('username', data.userName);
}

export function getUsername() {
    return localStorage.getItem('username');
}

export function getAvatar() {
    let username = getUsername();
    return `img/avatars/${username}.jpg`;
}

export function clearToken() {
    return localStorage.removeItem('token');
}

export function requestToken(username, password) {
    const body = urlEncode({
        grant_type: 'password',
        username,
        password
    });

    return fetch(`${base}/Token`, {
        method: methods.POST,
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded;charset=UTF-8'
        },
        body
    }).catch(catchNetworkError).then(res => res.json());
}

export function openapi(method, route, data, params) {
    let url = `${base}/api/${route}`;
    let body = null;
    if (data) {
        if ((method === methods.PUT || method === methods.DELETE) && data.ID) {
            url += `/${data.ID}`;
        }
        Object.keys(data).forEach((key) => (data[key] == null) && delete data[key]);
        body = JSON.stringify(data);
    }
    if (params) {
        url += `?${urlEncode(params)}`;
    }
    let options = {
        method: method,
        headers: new Headers({
            'Authorization': 'Bearer ' + getToken(),
            'Content-Type': 'application/json'
        })
    };
    if (method !== methods.GET) {
        options.body = body;
    }
    return fetch(url, options).catch(catchNetworkError).then(res => {
        console.log(res.headers.get('content-type'))
        if (res.headers.get('content-type')) {
            return res.json();
        } else {
            return res.text();
        }
    });
}

// x-www-form-urlencoded
export const urlEncode = data => Object.keys(data)
    .map(key => encodeURIComponent(key) + '=' + encodeURIComponent(data[key]))
    .join('&');

export const catchNetworkError = error => {
    alert('Network error. View console logs for more detail!')
    console.error(error);
}