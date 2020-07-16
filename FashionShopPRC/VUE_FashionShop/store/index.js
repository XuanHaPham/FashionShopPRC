export const state = () => ({
  // products: [
  //   {
  //     id: 1,
  //     title: 'Product 1',
  //     description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit',
  //     price: 50,
  //     ratings: 3,
  //     reviews: 5,
  //     addedToCart: false,
  //     addedBtn: false,
  //     favourite: false,
  //     buyquantity: 1
  //   },
  //   {
  //     id: 2,
  //     title: 'Product 2',
  //     description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit',
  //     price: 35,
  //     ratings: 5,
  //     reviews: 10,
  //     addedToCart: false,
  //     addedBtn: false,
  //     favourite: false,
  //     buyquantity: 1
  //   },
  //   {
  //     id: 3,
  //     title: 'Product 3',
  //     description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit',
  //     price: 110,
  //     ratings: 2,
  //     reviews: 3,
  //     addedToCart: false,
  //     addedBtn: false,
  //     favourite: false,
  //     buyquantity: 1
  //   },
  //   {
  //     id: 4,
  //     title: 'Product 4',
  //     description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit',
  //     price: 50,
  //     ratings: 1,
  //     reviews: 0,
  //     addedToCart: false,
  //     addedBtn: false,
  //     favourite: false,
  //     buyquantity: 1
  //   },
  //   {
  //     id: 5,
  //     title: 'Product 5',
  //     description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit',
  //     price: 35,
  //     ratings: 4,
  //     reviews: 2,
  //     addedToCart: false,
  //     addedBtn: false,
  //     favourite: false,
  //     buyquantity: 1
  //   },
  //   {
  //     id: 6,
  //     title: 'Product 6',
  //     description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit',
  //     price: 110,
  //     ratings: 5,
  //     reviews: 1,
  //     addedToCart: false,
  //     addedBtn: false,
  //     favourite: false,
  //     buyquantity: 1
  //   },
  //   {
  //     id: 7,
  //     title: 'Product 7',
  //     description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit',
  //     price: 50,
  //     ratings: 5,
  //     reviews: 7,
  //     addedToCart: false,
  //     addedBtn: false,
  //     favourite: false,
  //     buyquantity: 1
  //   },
  //   {
  //     id: 12,
  //     title: 'Product 12',
  //     description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit',
  //     price: 35,
  //     ratings: 3,
  //     reviews: 0,
  //     addedToCart: false,
  //     addedBtn: false,
  //     favourite: false,
  //     buyquantity: 1
  //   },
  //   {
  //     id: 11,
  //     title: 'Product 11',
  //     description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit',
  //     price: 35,
  //     ratings: 3,
  //     reviews: 0,
  //     addedToCart: false,
  //     addedBtn: false,
  //     favourite: false,
  //     buyquantity: 1
  //   },
  //   {
  //     id: 8,
  //     title: 'Product 8',
  //     description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit',
  //     price: 35,
  //     ratings: 3,
  //     reviews: 0,
  //     addedToCart: false,
  //     addedBtn: false,
  //     favourite: false,
  //     buyquantity: 1
  //   },
  //   {
  //     id: 10,
  //     title: 'Product 10',
  //     description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit',
  //     price: 35,
  //     ratings: 3,
  //     reviews: 0,
  //     addedToCart: false,
  //     addedBtn: false,
  //     favourite: false,
  //     buyquantity: 1
  //   },
  //   {
  //     id: 9,
  //     title: 'Product 9',
  //     description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit',
  //     price: 110,
  //     ratings: 4,
  //     reviews: 2,
  //     addedToCart: false,
  //     addedBtn: false,
  //     favourite: false,
  //     buyquantity: 1
  //   }
  // ],
  products:[],
  userInfo: {
    isLoggedIn: false,
    isSignedUp: false,
    isPassword: false,
    isUpdate: false,
    hasSearched: false,
    hasCategory: false,
    ID:'',
    name: '',
    productTitleSearched: '',
    productTitleCategory: '',
    email: '',
    phoneNumber: '',
    address: '',
    fullName: '',
    dob: '',
    password:'',
    shippingAddress: '',
    status: true
  },
  systemInfo: {
    openLoginModal: false,
    openSignupModal: false,
    openUpdateModal: false,
    openPasswordModal: false,
    openCheckoutModal: false
  }
})

export const getters = {
  productsAdded: state => {
    return state.products.filter(el => {
      return el.addedToCart;
    });
  },
  productsAddedToFavourite: state => {
    return state.products.filter(el => {
      return el.favourite;
    });
  },
  getProductById: state => id => {
    return state.products.find(product => product.id == id);
  },
  isUserLoggedIn: state => {
    return state.userInfo.isLoggedIn;
  },
  isUserSignedUp: state => {
    return state.userInfo.isSignedUp;
  },
  isUserPassword: state => {
    return state.userInfo.isPassword;
  },
  isUserUpdate: state => {
    return state.userInfo.isUpdate;
  },
  getUserName: state => {
    return state.userInfo.name;
  },
  getID: state => {
    return state.userInfo.ID;
  },
  getPassword: state => {
    return state.userInfo.password;
  },
  getAddress: state => {
    return state.userInfo.address;
  },
  getAddress1: state => {
    return state.userInfo.shippingAddress;
  },
  getPhoneNumber: state => {
    return state.userInfo.phoneNumber;
  },
  getDOB: state => {
    return state.userInfo.dob;
  },
  getEmail: state => {
    return state.userInfo.email;
  },
  getFullname: state => {
    return state.userInfo.fullName;
  },
  isLoginModalOpen: state => {
    return state.systemInfo.openLoginModal;
  },
  isSignupModalOpen: state => {
    return state.systemInfo.openSignupModal;
  },
  isUpdateModalOpen: state => {
    return state.systemInfo.openUpdateModal;
  },
  isPasswordModalOpen: state => {
    return state.systemInfo.openPasswordModal;
  },
  isCheckoutModalOpen: state => {
    return state.systemInfo.openCheckoutModal;
  },
  buyquantity: state => {
    return state.products.buyquantity;
  }
}

export const mutations = {
  addToCart: (state, id) => {
    state.products.forEach(el => {
      if (id === el.id) {
        el.addedToCart = true;
      }
    });
  },
  setAddedBtn: (state, data) => {
    state.products.forEach(el => {
      if (data.id === el.id) {
        el.addedBtn = data.status;
      }
    });
  },
  removeFromCart: (state, id) => {
    state.products.forEach(el => {
      if (id === el.id) {
        el.addedToCart = false;
      }
    });
  },
  removeProductsFromFavourite: state => {
    state.products.filter(el => {
      el.favourite = false;
    });
  },
  setProducts: (state, newProduct) => {
    state.product= null;
    state.products = newProduct;
   
  },
  isUserLoggedIn: (state, isUserLoggedIn) => {
    state.userInfo.isLoggedIn = isUserLoggedIn;
  },
  isUserSignedUp: (state, isSignedUp) => {
    state.userInfo.isSignedUp = isSignedUp;
  },
  isUserPassword: (state, isPassword) => {
    state.userInfo.isPassword = isPassword;
  },
  isUserUpdate: (state, isUpdate) => {
    state.userInfo.isUpdate = isUpdate;
  },
  setHasUserSearched: (state, hasSearched) => {
    state.userInfo.hasSearched = hasSearched;
  },
  setHasUserCategory: (state, hasCategory) => {
    state.userInfo.hasCategory = hasCategory;
  },
  setUserName: (state, name) => {
    state.userInfo.name = name;
  },
  setPassword: (state, password) => {
    state.userInfo.password = password;
  },
  setID: (state,ID) => {
    state.userInfo.ID = ID;
  },
  setAddress: (state, address) => {
    state.userInfo.address = address;
  },
  setAddress1: (state, shippingAddress) => {
    state.userInfo.shippingAddress = shippingAddress;
  },
  setPhoneNumber: (state, phoneNumber) => {
    state.userInfo.phoneNumber = phoneNumber;
  },
  setEmail: (state, email) => {
    state.userInfo.email = email;
  },
  setDOB: (state, dob) => {
    state.userInfo.dob = dob;
  },
  setFullName: (state, fullName) => {
    state.userInfo.fullName = fullName;
  },
  setProductTitleSearched: (state, titleSearched) => {
    state.userInfo.productTitleSearched = titleSearched;
  },
  setProductTitleCategory: (state, titleCategory) => {
    state.userInfo.productTitleCategory = titleCategory;
  },
  showLoginModal: (state, show) => {
    state.systemInfo.openLoginModal = show;
  },
  showSignupModal: (state, show  ) => {
    state.systemInfo.openSignupModal = show;
  },
  showPasswordModal: (state, show) => {
    state.systemInfo.openPasswordModal = show;
  },
  showUpdateModal: (state, show) => {
    state.systemInfo.openUpdateModal = show;
  },
  showCheckoutModal: (state, show) => {
    state.systemInfo.openCheckoutModal = show;
  },
  addToFavourite: (state, id) => {
    state.products.forEach(el => {
      if (id === el.id) {
        el.favourite = true;
      }
    });
  },
  removeFromFavourite: (state, id) => {
    state.products.forEach(el => {
      if (id === el.id) {
        el.favourite = false;
      }
    });
  },
  buyquantity: (state, data) => {
    state.products.forEach(el => {
      if (data.id === el.id) {
        el.buyquantity = data.buyquantity;
      }
    });
  },
  SET_USER(state, authUser) {
    state.authUser = authUser
  }
}
/* 
export const actions = {
  async nuxtServerInit({ commit }) {
    const res = await this.$axios.get("/api/current_user")
    commit("SET_USER", res.data)
  },

  async logout({ commit }) {
    const { data } = await this.$axios.get("/api/logout")
    if (data.ok) commit("SET_USER", null)
  },

  async handleToken({ commit }, token) {
    const res = await this.$axios.post("/api/stripe", token)
    commit("SET_USER", res.data)
  }
} */

export const base = 'http://localhost:8080'

export const methods = {
    GET: 'GET',
    POST: 'POST',
    PUT: 'PUT',
    DELETE: 'DELETE'
}

export function _parseJSON(response) {
  return response.text().then(function(text) {
    return text ? JSON.parse(text) : {}
  })
}


export const routes = {
    ACCOUNT: 'accounts',
    PASSWORD: 'accounts/updatePassword',
    FEEDBACK: 'feedback',
    GETPRODUCTS: 'products/getAllProduct',
    ORDERS: 'bills',
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

// export function setToken(data) {
  
//     localStorage.setItem('ussername', data.username);
//     localStorage.setItem('token', data.access_token);
//     localStorage.setItem('email', data.email);
//     localStorage.setItem('phoneNumber', data.phoneNumber);
//     localStorage.setItem('address', data.address);
//     localStorage.setItem('shippingAddress', data.shippingAddress);
//     localStorage.setItem('fullName', data.fullName);
//     localStorage.setItem('dob', data.dob);
    
    
// }

// export function getUsername() {
//     return localStorage.getItem('username');
// }

// export function getAddress() {
//   return localStorage.getItem('address');
// }

// export function getAddress1() {
//   return localStorage.getItem('shippingAddress');
// }

// export function getPhoneNumber() {
//   return localStorage.getItem('phoneNumber');
// }

// export function getDOB() {
//   return localStorage.getItem('dob');
// }

// export function getEmail() {
//   return localStorage.getItem('email');
// }


// export function getFullname() {
//   return localStorage.getItem('fullname');
// }

export function getAvatar() {
    let username = getUsername();
    return `img/avatars/${username}.jpg`;
}

export function clearToken() {
    return localStorage.removeItem('token');
}

export function requestToken(username, password) {
    const body = urlEncode({
        // grant_type: 'password',
        username,
        password
    });

    return fetch(`${base}/authencation/checkLogin`, {
        method: methods.POST,
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        body
    }).catch(catchNetworkError).then(res => 
      // res.json()
      _parseJSON(res)
      );
}

export function openapi(method, route, data, params) {
    let url = `${base}/${route}`;
    let body = null;
    if (data) {
        // if ((method === methods.PUT || method === methods.DELETE) && data.id) {
        //     url += `/${data.id}`;
        // }
        Object.keys(data).forEach((key) => (data[key] == null) && delete data[key]);
        body = JSON.stringify(data);
    }
    if (params) {
        url += `?${urlEncode(params)}`;
    }
    let options = {
        method: method,
        headers: new Headers({
            'Content-Type': 'application/json'
        })
    };
    if (method !== methods.GET) {
        options.body = body;
    }
    return fetch(url, options).catch(catchNetworkError).then(res => {
        console.log(res.headers.get('Content-Type'))
        if (res.headers.get('Content-Type')) {
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

export function register(user) {
  const requestOptions = {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(user)
  };

  return fetch(`${base}/accounts`, requestOptions).then(handleResponse);
}
