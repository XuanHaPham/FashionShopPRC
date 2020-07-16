<template>
  <div class="section">
    <div class="card is-clearfix columns">
        <figure class="card-image is-480x480 column is-one-thirds">
          <img v-if="product.categoryID == 4" src="https://cdn10.bigcommerce.com/s-9ccdlm/products/6271/images/59396/AE6AA6C97CF7DEEE7662EDFD629836B8__55875.1515575456.1280.1280.jpg?c=2" alt="Placeholder image">
        <img v-if="product.categoryID == 3" src="https://cdn10.bigcommerce.com/s-9ccdlm/products/5445/images/52202/2972797472_1858141507__73192.1470194562.1280.1280.jpg?c=2" alt="Placeholder image">
        <img v-if="product.categoryID == 5" src="https://cdn10.bigcommerce.com/s-9ccdlm/products/5566/images/53748/QQ20160730110501__88422.1474434359.1280.1280.jpg?c=2" alt="Placeholder image">
        <img v-if="product.categoryID == 6" src="https://cdn10.bigcommerce.com/s-9ccdlm/products/1436/images/10610/D134.5__54183.1432361205.1280.1280.jpg?c=2" alt="Placeholder image">
        <img v-if="product.categoryID == 7" src="https://cdn10.bigcommerce.com/s-9ccdlm/products/5541/images/53023/Unnamed_QQ_Screenshot20160823113330__39887.1471923697.1280.1280.png?c=2" alt="Placeholder image">
        <img v-if="product.categoryID == 8" src="https://cdn10.bigcommerce.com/s-9ccdlm/products/6162/images/58765/9163681FAC7278476AE2D8204D14C756__41465.1509080996.500.659.jpg?c=2" alt="Placeholder image">
        <img v-if="product.categoryID == 9" src="https://cdn10.bigcommerce.com/s-9ccdlm/products/3987/images/40633/First_photo_1__96693.1455262717.190.250.jpg?c=2" alt="Placeholder image">
        <img v-if="product.categoryID == 10" src="https://cdn10.bigcommerce.com/s-9ccdlm/products/6692/images/64229/QQ_Photo20190315160210__78348.1553136543.190.250.jpg?c=2" alt="Placeholder image">
        <img v-if="product.categoryID == 11" src="https://cdn10.bigcommerce.com/s-9ccdlm/products/6364/images/60243/SW609_6__12058.1521196381.190.250.jpg?c=2" alt="Placeholder image">
        <img v-if="product.categoryID == 12" src="https://cdn10.bigcommerce.com/s-9ccdlm/products/6427/images/61148/5__27874.1522997351.190.250.jpg?c=2" alt="Placeholder image">
        <img v-if="product.categoryID == 13" src="https://cdn10.bigcommerce.com/s-9ccdlm/products/6015/images/57646/SW100_Change_Photo1__89088.1461575338.1280.1280_1800x__67855.1496813830.190.250.jpg?c=2" alt="Placeholder image">
      </figure>
        <div class="card-content column is-two-thirds">
          <div class="card-content__title">
            <h1 class="title is-4">{{ product.name}}
              <button class="button is-small" :title="removeFromFavouriteLabel" v-show="product.favourite" @click="removeFromFavourite(product.id)">
                <span class="icon is-small">
                  <i class="fa fa-heart"></i>
                </span>
              </button>
              <button class="button is-small" :title="addToFavouriteLabel" v-show="!product.favourite" @click="saveToFavorite(product.id)">
                <span class="icon is-small">
                  <i class="fa fa-heart-o"></i>
                </span>
              </button>
              <h2>
              
            Code: {{ product.code }}
            </h2>
            </h1>
            
          </div>
          <div class="card-content__text">
            
            <p>
           Description: {{ product.description }}
            </p>
            <p>
            Size: {{ product.size }}
            </p>
          </div>
          <!-- <div class="card-content__ratings" v-if="product.rating === 1">
            <i class="fa fa-star"></i>
          </div>
          <div class="card-content__ratings" v-else-if="product.rating === 2">
            <i class="fa fa-star"></i>
            <i class="fa fa-star"></i>
          </div>
          <div class="card-content__ratings" v-else-if="product.rating === 3">
            <i class="fa fa-star"></i>
            <i class="fa fa-star"></i>
            <i class="fa fa-star"></i>
          </div>
          <div class="card-content__ratings" v-else-if="product.rating === 4">
            <i class="fa fa-star"></i>
            <i class="fa fa-star"></i>
            <i class="fa fa-star"></i>
            <i class="fa fa-star"></i>
          </div>
          <div class="card-content__ratings" v-else-if="product.rating === 5">
            <i class="fa fa-star"></i>
            <i class="fa fa-star"></i>
            <i class="fa fa-star"></i>
            <i class="fa fa-star"></i>
            <i class="fa fa-star"></i>
          </div> -->
          <div class="card-content__reviews">
            <!-- <div class="is-pulled-left">
              <p><strong>{{ product.reviews > 0 ? `${product.reviews} Reviews` : 'No reviews' }}</strong></p>
            </div> -->
            <div class="select is-rounded is-small is-pulled-right">
              <select @change="onSelectbuyquantity(product.id)" v-model="selected">
                <option v-for="buyquantity in buyquantityArray" :value="buyquantity">{{ buyquantity }}</option>
              </select>
            </div>
          </div>
          <div class="card-content__price is-pulled-left">
            <span class="title is-3"><strong>{{ product.price }}&dollar;</strong></span>
          </div>
          <div class="card-content__btn is-pulled-right">
            <button class="button is-primary" v-if="!addedBtn" @click="addToCart(product.id)">{{ addToCartLabel }}</button>
            <button class="button is-text" v-if="addedBtn" @click="removeFromCart(product.id)">{{ removeFromCartLabel }}</button>
          </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'product_detail-id',

  validate ({ params }) {
    return /^\d+$/.test(params.id)
  },
  
  data () {
    return {
      addToCartLabel: 'Add to cart',
      removeFromCartLabel: 'Remove from cart',
      addToFavouriteLabel: 'Add to favourite',
      removeFromFavouriteLabel: 'Remove from favourite',
      product: {},
      selected: 1,
      buyquantityArray: []
    };
  },

  mounted () {
    this.product = this.$store.getters.getProductById(this.$route.params.id);
    this.selected = this.product.buyquantity;

    for (let i = 1; i <= this.product.quantity; i++) {
      this.buyquantityArray.push(i);
    }
  },

  computed: {
    addedBtn () {
      return this.product.addedBtn;
    }
  },

  methods: {
    addToCart (id) {
      let data = {
        id: id,
        status: true
      }
      this.$store.commit('addToCart', id);
      this.$store.commit('setAddedBtn', data);
    },
    removeFromCart (id) {
      let data = {
        id: id,
        status: false
      }
      this.$store.commit('removeFromCart', id);
      this.$store.commit('setAddedBtn', data);
    },
    onSelectbuyquantity (id) {
      let data = {
        id: id,
        buyquantity: this.selected
      }
      this.$store.commit('buyquantity', data);
    },
    saveToFavorite (id) {
      let isUserLogged = this.$store.state.userInfo.isLoggedIn;

      if (isUserLogged) {
        this.$store.commit('addToFavourite', id);
      } else {
        this.$store.commit('showLoginModal', true);
      }
    },
    removeFromFavourite (id) {
      this.$store.commit('removeFromFavourite', id);
    }
  }
};
</script>

<style lang="scss" scoped>
  .card-content {
    padding: 15px 10px 15px 0;

    &__text {
      margin: 15px 0;
    }
    &__reviews {
      display: inline-block;
      width: 100%;
      margin-bottom: 10px;
    }
  }
  figure {
    align-content: center;
    align-self: center;
  }
</style>

