<template>
  <div class="columns is-centered is-multiline">
  
    <div class="card column is-one-quarter" v-for="product in products" :key="product.id">
      <VmProducts :product="product"></VmProducts>
    </div>
    <div class="section" v-if="products.length === 0">
      <p>{{ noProductLabel }}</p>
    </div>
  </div>
</template>

<script>
import VmProducts from '../Products';
import { getByTitle, getByCategory } from '@/assets/filters';
import { base, openapi, methods, routes, setToken, requestToken } from '@/store/index.js'
import axios from 'axios';

export default {
  name: 'productsList',
  
  components: { VmProducts },
  
  data () {
    return {
      id: '',
      noProductLabel: 'No product found',
      productsFiltered: []
    };
  },
  mounted(){
    // openapi(methods.GET, routes.GETPRODUCTS).then(data => {
    //     console.log(data);
    //     this.$store.commit('setProducts', data);
    //   })
    axios.get('https://localhost:44395/products/getAllProduct')
      .then((response) => {
        console.log(response);
        this.$store.commit('setProducts', response.data);
      });
  },
  computed: {
    products () {
      if (this.$store.state.userInfo.hasSearched && this.$store.state.userInfo.hasCategory) {
        let list= this.getProductByTitle();
        return this.getProductByCategory(list);
      } 
      else if(this.$store.state.userInfo.hasSearched){
        return this.getProductByTitle();
      }
      else if(this.$store.state.userInfo.hasCategory){
        let list= this.getProductByTitle(this.$store.state.products);
        return this.getProductByCategory(list);
      }
      else {
        return this.$store.state.products;
      }
    }
  },

  methods: {
    getProductByTitle () {
      let listOfProducts = this.$store.state.products,
          titleSearched = this.$store.state.userInfo.productTitleSearched;
      
      return this.productsFiltered = getByTitle(listOfProducts, titleSearched);
    },

     getProductByCategory (listOfProducts) {
       let   titleSearched = this.$store.state.userInfo.productTitleCategory;
      
      return this.productsFiltered = getByCategory(listOfProducts, titleSearched);
    }
  }

};
</script>

<style lang="scss" scoped>
  .card {
    margin: 10px;
  }
</style>
