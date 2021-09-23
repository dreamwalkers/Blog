import Head from 'next/head'
import Link from 'next/link'
import Layout, { siteTitle } from '../components/layout'
import utilStyles from '../styles/utils.module.css'

export default function Home() {
  return (
    // <Layout home>
    <Layout home>
      <Head>
        <title>{siteTitle}</title>
      </Head>
      <section className={utilStyles.headingMd}>
        <p>Howdy partner</p>
        <p>
          This is my sample <b>React app with Nextjs</b>.{' '}
          
          Read my <Link href="/posts/first-post"><a className={utilStyles.firstpost}>First Post</a></Link>.{' '}
        </p>
      </section>
    </Layout>
  )
}