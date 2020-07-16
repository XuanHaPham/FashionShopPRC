<template>
  <div class="footer">
    <div class="columns container">
      
    <div class="column is-4">
 <p style="color:yellow">Contact Us</p>
       <p>Eazy Fashion Inc.</p>
       <p>Address: Ho Chi Minh City, Viet Nam</p>
        <p>Phone Number: 0901456498</p>
        <p>Email: info@eazyshop.com</p>
      </div>
      <div class="column is-4
is-offset-6 ">
        <p style="color:yellow">Connect with us</p>
        <div class="navbar-item social">
        <a href="https://www.facebook.com/eazyfashi0n/" class="icon is-size-1 has-text-white-bis" :title="facebookTooltip">
              <i class="fa fa-facebook"></i>
            </a>
            <a href="https://twitter.com/ezayfashion" class="icon is-size-1 has-text-white-bis" :title="twitterTooltip">
              <i class="fa fa-twitter is-large"></i>
            </a>
            <a href="https://www.instagram.com/eazyfashionph/" class="icon is-size-1 has-text-white-bis" :title="instagramTooltip">
              <i class="fa fa-instagram"></i>
            </a>
            <a href="https://www.linkedin.com/company/easy-fashion-ltd-/about/" class="icon is-size-1 has-text-white-bis" :title="linkedinTooltip">
              <i class="fa fa-linkedin"></i>
            </a>
        </div>
    </div>
    </div>
  </div>
</template>

<script>
export default {
  
  name: 'VmFooter',
   data () {
      return {
        linkedinTooltip: 'Follow us on Linkedin',
        facebookTooltip: 'Follow us on Facebook',
        twitterTooltip: 'Follow us on Twitter',
        instagramTooltip: 'Follow us on Instagram',
        isCheckoutActive: false,
        isMenuOpen: false
      }
    },
}
</script>

<style lang="scss" scoped>
 .footer {
   margin-top: 20px;
   background: palevioletred;
   color: white;
 }
p{
  margin-left: 30px;
  font-size: 18px;
}
 a {
    margin: 30px;
  }
</style>
